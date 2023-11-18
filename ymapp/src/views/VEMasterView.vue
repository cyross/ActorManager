<script setup lang="ts">
import { ref, computed, onMounted } from 'vue'
import type { Ref } from 'vue'
import type { AxiosResponse } from 'axios'

import { useVEStore } from '../stores/ve'
import { useConfigStore } from '../stores/config'
import { useErrorAlertStore, useNoticeAlertStore } from '../stores/alert'

import { callApi, callPostApi, callPutApi, callDeleteApi } from '../utils/apiCall'

import AlertsComponent from '../components/AlertsComponent.vue'
import ModalDialog from '../components/dialogs/ModalDialog.vue'
import Col2TitleColumn from '../components/cols/Col2TitleCol.vue'
import EditAndDeleteRow from '../components/rows/EditAndDeleteRow.vue'
import DetailRow from '../components/rows/DetailRow.vue'
import DialogShowButtonCol from '../components/cols/DialogShowButtonCol.vue'
import CancelButtonCol from '../components/cols/CancelButtonCol.vue'
import NewButtonRow from '../components/rows/NewButtonRow.vue'
import EditExtDataRow from '../components/rows/EditExtDataRow.vue'
import ExtDataRow from '../components/rows/ExtDataRow.vue'
import NameButtonList from '../components/NameButtonList.vue'

const errorAlertStore = useErrorAlertStore()
const noticeAlertStore = useNoticeAlertStore()
const veStore = useVEStore()
const configStore = useConfigStore()

const loaded: Ref<Boolean> = ref(false)

const showVEDetail = (index: number) => {
  errorAlertStore.clear()
  noticeAlertStore.clear()

  const getDetailApi = `${configStore.apiBaseURL}/api/v1/VoiceEngineSpec/${index}/`

  callApi(getDetailApi, null, '音声合成エンジン詳細取得エラー', (response: AxiosResponse) => {
    veStore.setDetail(index, response.data.Spec)
  })
}

const resetVEView = () => {
  veStore.editDisable()
  veStore.resetDetail()
}

const newEdit = () => {
  veStore.newEdit()
}

const addExt = (key: string, value: string) => {
  veStore.addExtData(key, value)
}

const removeExt = (key: string) => {
  veStore.removeExtData(key)
}

const addVEOK = () => {
  veStore.applyDetailFromEdit(veStore.edit)

  const title = veStore.titleByEdit

  const putApi = `${configStore.apiBaseURL}/api/v1/VoiceEngineSpec/`

  callPutApi(
    putApi,
    veStore.detail.Body,
    `${title}の追加に成功しました`,
    `${title}の追加エラー`,
    (response: AxiosResponse) => {
      console.log(`returns ${response.status}`)

      veStore.appendName({
        Id: response.data.NewId,
        Name: veStore.detail.Body.Name
      })

      resetVEView()
    }
  )
}

const updateVEOK = () => {
  veStore.applyDetailFromEdit(veStore.edit)

  const id = veStore.detail.Body.Id
  const name = veStore.detail.Body.Name
  const title = veStore.titleByEdit

  const postApi = `${configStore.apiBaseURL}/api/v1/VoiceEngineSpec/${id}`

  callPostApi(
    postApi,
    veStore.detail.Body,
    `${title}の更新に成功しました`,
    `${title}の更新エラー`,
    (response: AxiosResponse) => {
      console.log(`returns ${response.status}`)

      veStore.updateNameById(id, { Id: id, Name: name })

      resetVEView()
    }
  )
}

const deleteVEOK = () => {
  const id = veStore.detail.Body.Id
  const title = veStore.titleByEdit

  const deleteApi = `${configStore.apiBaseURL}/api/v1/VoiceEngineSpec/${id}`

  callDeleteApi(
    deleteApi,
    `${title}の削除に成功しました`,
    `${title}の削除エラー`,
    (response: AxiosResponse) => {
      console.log(`returns ${response.status}`)

      veStore.deleteNameById(id)

      resetVEView()
    }
  )
}

const showEditVE = () => {
  veStore.applyEditFromDetail()
  veStore.editEnable()
}

const hideEditVE = () => {
  veStore.editDisable()
}

const isShowEdit = computed(() => {
  return veStore.visibleEdit
})

const isShowDetail = computed(() => {
  return veStore.visibleDetail
})

const isShowVEAddButton = computed(() => {
  return veStore.isAdd
})

const isShowVEUpdateButton = computed(() => {
  return veStore.isUpdate
})

const addNotice = computed(() => {
  return `${veStore.titleByEdit} を追加します。よろしいですか？`
})

const updateNotice = computed(() => {
  return `${veStore.titleByDetailAndEdit} を更新します。よろしいですか？`
})

const deleteNotice = computed(() => {
  return `${veStore.titleByDetail} を削除します。よろしいですか？`
})

const encodeList = computed((): Array<string> => {
  return veStore.encodes
})

const sepList = computed((): Array<string> => {
  return veStore.separators
})

onMounted(() => {
  loaded.value = false

  const getNamesApi = `${configStore.apiBaseURL}/api/v1/VoiceEngineSpec/Index/`

  callApi(getNamesApi, null, '音声合成エンジン詳細取得エラー', (response: AxiosResponse) => {
    veStore.setNames(response.data.Names)

    loaded.value = true
  })
})
</script>

<template>
  <div class="container main-view overflow-auto">
    <AlertsComponent />
    <div v-if="!loaded" id="loading" class="d-flex align-items-center">
      <div class="spinner" variant="primary"></div>
    </div>
    <div v-else class="container">
      <NewButtonRow v-if="!veStore.visibleEdit" :showFunc="newEdit" />
      <div v-if="veStore.visibleEdit" class="row">
        <div class="container">
          <div class="row py-1">
            <Col2TitleColumn title="名前" />
            <div class="col">
              <div class="col">
                <input v-model="veStore.edit.Name" class="form-control-sm" placeholder="名前" />
              </div>
            </div>
          </div>
          <div class="row py-1">
            <Col2TitleColumn title="正式名称" />
            <div class="col">
              <input
                v-model="veStore.edit.RealName"
                class="form-control-sm"
                placeholder="正式名称"
              />
            </div>
          </div>
          <div class="row py-1">
            <Col2TitleColumn title="区切り文字" />
            <div class="col">
              <select v-model="veStore.edit.Separator" class="form-select-sm">
                <option v-for="(sep, index) in sepList" v-bind:key="index" :value="sep">
                  {{ sep }}
                </option>
              </select>
            </div>
          </div>
          <div class="row py-1">
            <Col2TitleColumn title="エンコーディング" />
            <div class="col">
              <select v-model="veStore.edit.Encoding" class="form-select-sm">
                <option v-for="(encode, index) in encodeList" v-bind:key="index" :value="encode">
                  {{ encode }}
                </option>
              </select>
            </div>
          </div>
          <EditExtDataRow :ext="veStore.edit.ExtData" :addFunc="addExt" :removeFunc="removeExt" />
          <div class="row py-1">
            <DialogShowButtonCol
              v-if="isShowVEAddButton"
              id="confirm-add-ve"
              title="登録"
              variant="danger"
            />
            <DialogShowButtonCol
              v-if="isShowVEUpdateButton"
              id="confirm-update-ve"
              title="追加"
              variant="warning"
            />
            <DialogShowButtonCol
              v-if="isShowVEUpdateButton"
              id="confirm-update-ve"
              title="更新"
              variant="danger"
            />
            <CancelButtonCol :cancelFunc="hideEditVE" />
          </div>
        </div>
      </div>
      <div class="row py-1">
        <div v-if="!isShowEdit" class="row">
          <div class="col-auto">
            <NameButtonList :names="veStore.names" :showFunc="showVEDetail" />
          </div>
          <div class="col">
            <div class="row detail-box">
              <div v-if="!isShowDetail" class="col">
                <p>音声合成エンジンを選択してください</p>
              </div>
              <div v-else class="col">
                <div class="row">
                  <div class="col">
                    <DetailRow title="名前" :value="veStore.detail.Body.Name" />
                    <DetailRow title="正式名称" :value="veStore.detail.Body.RealName" />
                    <DetailRow title="区切り文字" :value="veStore.detail.Body.Separator" />
                    <DetailRow title="文字コード" :value="veStore.detail.Body.Encoding" />
                    <ExtDataRow :ext="veStore.detail.Body.ExtData" />
                  </div>
                </div>
                <div class="row">
                  <div class="col">
                    <EditAndDeleteRow :editFunc="showEditVE" deleteModalId="confirm-delete-ve" />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <ModalDialog
      id="confirm-add-ve"
      title="エンジン情報追加の確認"
      :notice="addNotice"
      :okFunc="addVEOK"
    />
    <ModalDialog
      id="confirm-update-ve"
      title="エンジン情報更新の確認"
      :notice="updateNotice"
      :okFunc="updateVEOK"
    />
    <ModalDialog
      id="confirm-delete-ve"
      title="エンジン情報削除の確認"
      :notice="deleteNotice"
      :okFunc="deleteVEOK"
    />
  </div>
</template>
