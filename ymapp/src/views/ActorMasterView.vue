<script setup lang="ts">
import { ref, computed, onMounted } from "vue";
import type { Ref } from "vue";
import type { AxiosResponse } from "axios";

import { useActorStore } from "../stores/actor";
import { useVEStore } from "../stores/ve";
import { useColorStore } from "../stores/colors";
import { useConfigStore } from "../stores/config";
import { useErrorAlertStore, useNoticeAlertStore } from "../stores/alert";

import { callApi, callPostApi, callPutApi, callDeleteApi } from "../utils/apiCall";

import AlertsComponent from "../components/AlertsComponent.vue";
import ModalDialog from "../components/dialogs/ModalDialog.vue";
import EmptyRow from "../components/rows/EmptyRow.vue";
import Col4TitleColumn from "../components/cols/Col4TitleCol.vue";
import EditAndDeleteRow from "../components/rows/EditAndDeleteRow.vue";
import DetailRow from "../components/rows/DetailRow.vue";
import ListDetailRow from "../components/rows/ListDetailRow.vue";
import DialogShowButtonCol from "../components/cols/DialogShowButtonCol.vue";
import CancelButtonCol from "../components/cols/CancelButtonCol.vue";
import NewButtonRow from "../components/rows/NewButtonRow.vue";
import EditExtDataRow from "../components/rows/EditExtDataRow.vue";
import ExtDataRow from "../components/rows/ExtDataRow.vue";
import ColorAttrRow from "../components/rows/ColorAttrRow.vue";
import InputColorRow from "../components/rows/InputColorRow.vue";
import NameButtonList from "../components/NameButtonList.vue";

const errorAlertStore = useErrorAlertStore();
const noticeAlertStore = useNoticeAlertStore();
const actorStore = useActorStore();
const veStore = useVEStore();
const colorStore = useColorStore();
const configStore = useConfigStore();

const loaded: Ref<Boolean> = ref(false);

const showActorDetail = (index: number) => {
  errorAlertStore.clear();
  noticeAlertStore.clear();

  const getDetailApi = `${configStore.apiBaseURL}/api/v1/ActorSpec/${index}/`;

  callApi(
    getDetailApi,
    null,
    "声優詳細取得エラー",
    (response: AxiosResponse) => {
      actorStore.setDetail(index, response.data.Spec);
    }
  )
};

const resetActorView = () => {
  actorStore.editDisable();
  actorStore.resetDetail();
};

const newEdit = () => {
  actorStore.newEdit();
};

const addExt = (key: string, value: string) => {
  actorStore.addExtData(key, value);
}

const removeExt = (key: string) => {
  actorStore.removeExtData(key);
};

const addActorOK = () => {
  actorStore.applyDetailFromEdit();

  const title = actorStore.titleByEdit;

  const putApi = `${configStore.apiBaseURL}/api/v1/ActorSpec/`;

  callPutApi(
    putApi,
    actorStore.detail.Body,
    `${title}の追加に成功しました`,
    `${title}の追加エラー`,
    (response: AxiosResponse) => {
      console.log(`returns ${response.status}`);

      actorStore.appendName({
        Id: response.data.NewId,
        Name: actorStore.detail.Body.Name,
      });

      resetActorView();
    }
  )
};

const updateActorOK = () => {
  actorStore.applyDetailFromEdit();

  const id = actorStore.detail.Body.Id;
  const name = actorStore.detail.Body.Name;
  const title = actorStore.titleByEdit;

  const postApi = `${configStore.apiBaseURL}/api/v1/ActorSpec/${id}`;

  callPostApi(
    postApi,
    actorStore.detail.Body,
    `${title}の更新に成功しました`,
    `${title}の更新エラー`,
    (response: AxiosResponse) => {
      console.log(`returns ${response.status}`);

      actorStore.updateNameById(id, { Id: id, Name: name });

      resetActorView();
    }
  )
};

const deleteActorOK = () => {
  const id = actorStore.detail.Body.Id;
  const title = actorStore.titleByEdit;

  const deleteApi = `${configStore.apiBaseURL}/api/v1/ActorSpec/${id}`;

  callDeleteApi(
    deleteApi,
    `${title}の削除に成功しました`,
    `${title}の削除エラー`,
    (response: AxiosResponse) => {
      console.log(`returns ${response.status}`);

      actorStore.deleteNameById(id);

      resetActorView();
    }
  )
};

const showEditActor = () => {
  actorStore.applyEditFromDetail();
  actorStore.editEnable();
};

const hideEditActor = () => {
  actorStore.editDisable();
};

const isShowEdit = computed(() => {
  return actorStore.visibleEdit;
});

const isShowDetail = computed(() => {
  return actorStore.visibleDetail;
});

const isShowActorAddButton = computed(() => {
  return actorStore.isAdd;
});

const isShowActorUpdateButton = computed(() => {
  return actorStore.isUpdate;
});

const addNotice = computed(() => {
  return `${actorStore.titleByEdit} を追加します。よろしいですか？`;
});

const updateNotice = computed(() => {
  return `${actorStore.titleByDetail} を更新します。よろしいですか？`;
});

const deleteNotice = computed(() => {
  return `${actorStore.titleByDetail} を削除します。よろしいですか？`;
});

const UpdateColorNameJT = (target: HTMLSelectElement) => {
  console.log(target.value);
  actorStore.selectChangedColor(actorStore.edit.JimakuAttr.TextColor, target.value);
};

const UpdateColorRgbJT = (target: HTMLInputElement) => {
  console.log(target.value);
  actorStore.selectRgb(actorStore.edit.JimakuAttr.TextColor, target.value);
};

const UpdateColorNameJO = (target: HTMLSelectElement) => {
  console.log(target.value);
  actorStore.selectChangedColor(actorStore.edit.JimakuAttr.OutlineColor, target.value);
};

const UpdateColorRgbJO = (target: HTMLInputElement) => {
  console.log(target.value);
  actorStore.selectRgb(actorStore.edit.JimakuAttr.OutlineColor, target.value);
};

const UpdateColorNameAT = (target: HTMLSelectElement) => {
  console.log(target.value);
  actorStore.selectChangedColor(actorStore.edit.ActorNameAttr.TextColor, target.value);
};

const UpdateColorRgbAT = (target: HTMLInputElement) => {
  console.log(target.value);
  actorStore.selectRgb(actorStore.edit.ActorNameAttr.TextColor, target.value);
};

const UpdateColorNameAO = (target: HTMLSelectElement) => {
  console.log(target.value);
  actorStore.selectChangedColor(actorStore.edit.ActorNameAttr.OutlineColor, target.value);
};

const UpdateColorRgbAO = (target: HTMLInputElement) => {
  console.log(target.value);
  actorStore.selectRgb(actorStore.edit.ActorNameAttr.OutlineColor, target.value);
};

const changeColorTypeJT = (target: HTMLInputElement) => {
  console.log(target.value);
}

const changeColorTypeJO = (target: HTMLInputElement) => {
  console.log(target.value);
}

const changeColorTypeAT = (target: HTMLInputElement) => {
  console.log(target.value);
}

const changeColorTypeAO = (target: HTMLInputElement) => {
  console.log(target.value);
}

onMounted(() => {
  loaded.value = false;

  const getActorNamesApi = `${configStore.apiBaseURL}/api/v1/ActorSpec/Index/`;

  callApi(
    getActorNamesApi,
    null,
    "声優名一覧取得エラー",
    (response: AxiosResponse) => {
      actorStore.setNames(response.data.Names);

      const getVENamesApi = `${configStore.apiBaseURL}/api/v1/VoiceEngineSpec/`;

      callApi(
        getVENamesApi,
        null,
        "音声合成エンジン名一覧取得エラー",
        (response: AxiosResponse) => {
          veStore.setSpecs(response.data.Specs);

          const colorSpecsApi: string = `${configStore.apiBaseURL}/api/v1/ColorSpec/All/`;

          callApi(
            colorSpecsApi,
            null,
            "色情報取得エラー",
            (response: AxiosResponse) => {
              colorStore.setSpecs(response.data.Specs);
              colorStore.setColorNames();
              colorStore.setNameToColor();

              loaded.value = true;
            }
          );
        }
      )
    }
  )
});
</script>

<template>
  <div class="container main-view">
    <AlertsComponent />
    <div v-if="!loaded" id="loading" class="d-flex align-items-center">
      <div class="spinner" variant="primary"></div>
    </div>
    <div v-else class="container">
      <NewButtonRow v-if="!actorStore.visibleEdit" :showFunc="newEdit" />
      <EmptyRow v-if="!actorStore.visibleEdit" />
      <div v-if="actorStore.visibleEdit" class="row">
        <div class="container">
          <div class="row">
            <Col4TitleColumn title="名前" />
            <div class="col">
              <div class="col">
                <input v-model="actorStore.edit.Name" class="form-control" placeholder="名前" />
              </div>
            </div>
          </div>
          <EmptyRow />
          <div class="row">
            <Col4TitleColumn title="かな" />
            <div class="col">
              <div class="col">
                <input v-model="actorStore.edit.Kana" class="form-control" placeholder="かな" />
              </div>
            </div>
          </div>
          <EmptyRow />
          <div class="row">
            <Col4TitleColumn title="対応音声合成エンジン" />
            <div class="col">
              <div
                v-for="(veName, index) in veStore.options"
                v-bind:key="index"
                class="input-group"
              >
                <input
                  :id="'ve_' + index"
                  type="checkbox"
                  :value="veName"
                  v-model="actorStore.edit.Engines"
                />
                &nbsp;{{  veName }}
              </div>
            </div>
          </div>
          <EmptyRow />
          <div class="row">
            <Col4TitleColumn title="別名" />
            <div class="col">
              <textarea
                v-model="actorStore.edit.AliasText"
                class="form-control"
                id="actorEditAliases"
              ></textarea>
              <ul>
                <li>別名を1行ずつ記載</li>
                <li>特定のエンジン名は後ろに"[エンジン名]"を入れる</li>
                <li>空行・空白のみの行は無視</li>
                <li>行の両端の空白は無視</li>
              </ul>
            </div>
          </div>
          <EmptyRow />
          <InputColorRow
            title="字幕文字色"
            :modelValue="actorStore.edit.JimakuAttr.TextColor"
            name="jimaku-text-color-type"
            :updateNameFunc="UpdateColorNameJT"
            :updateRgbFunc="UpdateColorRgbJT"
            :changeCheckFunc="changeColorTypeJT"
            />
          <EmptyRow />
          <InputColorRow
            title="字幕枠色"
            :modelValue="actorStore.edit.JimakuAttr.OutlineColor"
            name="jimaku-outline-color-type"
            :updateNameFunc="UpdateColorNameJO"
            :updateRgbFunc="UpdateColorRgbJO"
            :changeCheckFunc="changeColorTypeJO"
          />
          <EmptyRow />
          <div class="row">
            <Col4TitleColumn title="字幕枠幅" />
            <div class="col">
              <div class="col">
                <input v-model="actorStore.edit.JimakuAttr.OutlineWidth" type="number" class="form-control" placeholder="字幕枠幅" />
              </div>
            </div>
          </div>
          <EmptyRow />
          <div class="row">
            <div class="col-4">&nbsp;</div>
            <div class="col-1">
              <button
                v-on:click="
                  actorStore.copyEditTextInfo(
                    actorStore.edit.JimakuAttr,
                    actorStore.edit.ActorNameAttr
                  )
                "
                type="button"
                class="btn btn-info"
              >
                <i class="bi-arrow-down-circle"></i>
              </button>
            </div>
            <div class="col-1">&nbsp;</div>
            <div class="col-1">
              <button
                v-on:click="
                  actorStore.copyEditTextInfo(
                    actorStore.edit.ActorNameAttr,
                    actorStore.edit.JimakuAttr
                  )
                "
                type="button"
                class="btn btn-info"
              >
                <i class="bi-arrow-up-circle"></i>
              </button>
            </div>
            <div class="col">&nbsp;</div>
          </div>
          <EmptyRow />
          <InputColorRow
            title="声優名文字色"
            :modelValue="actorStore.edit.ActorNameAttr.TextColor"
            name="actor-name-text-color-type"
            :updateNameFunc="UpdateColorNameAT"
            :updateRgbFunc="UpdateColorRgbAT"
            :changeCheckFunc="changeColorTypeAT"
          />
          <EmptyRow />
          <InputColorRow
            title="声優名枠色"
            :modelValue="actorStore.edit.ActorNameAttr.OutlineColor"
            name="actor-name-outline-color-type"
            :updateNameFunc="UpdateColorNameAO"
            :updateRgbFunc="UpdateColorRgbAO"
            :changeCheckFunc="changeColorTypeAO"
          />
          <EmptyRow />
          <div class="row">
            <Col4TitleColumn title="声優名枠幅" />
            <div class="col">
              <div class="col">
                <input v-model="actorStore.edit.ActorNameAttr.OutlineWidth" type="number" class="form-control" placeholder="声優名枠幅" />
              </div>
            </div>
          </div>
          <EmptyRow />
          <EditExtDataRow :ext="actorStore.edit.ExtData" :addFunc="addExt" :removeFunc="removeExt" />
          <EmptyRow />
          <div class="row">
            <DialogShowButtonCol v-if="isShowActorAddButton" id="confirm-add-actor" title="登録" variant="danger" />
            <DialogShowButtonCol v-if="isShowActorUpdateButton" id="confirm-update-actor" title="追加" variant="warning" />
            <DialogShowButtonCol v-if="isShowActorUpdateButton" id="confirm-update-actor" title="更新" variant="danger" />
            <CancelButtonCol :cancelFunc="hideEditActor" />
          </div>
        </div>
      </div>
      <div v-else class="row">
        <div v-if="!isShowEdit" class="row">
          <div class="col-4 full_height">
            <NameButtonList :names="actorStore.names" :showFunc="showActorDetail" />
          </div>
          <div class="col">
            <div class="container">
              <div class="row half_height">
                <div v-if="!isShowDetail" class="d-flex detail_box">
                  <p>選択がされていません</p>
                </div>
                <div v-else class="d-flex detail_box">
                  <div class="container">
                    <DetailRow title="名前" :value="actorStore.detail.Body.Name" />
                    <DetailRow title="かな" :value="actorStore.detail.Body.Kana" />
                    <ListDetailRow title="対応音声合成エンジン" :list="actorStore.detail.Body.Engines" />
                    <ListDetailRow title="別名" :list="actorStore.detail.Body.AnotherNames" />
                    <ColorAttrRow title="字幕文字色" :color="actorStore.detail.Body.JimakuTextColor" />
                    <ColorAttrRow title="字幕枠色" :color="actorStore.detail.Body.JimakuOutlineColor" />
                    <DetailRow title="字幕枠幅" :value="actorStore.detail.Body.JimakuOutlineWidth.toString()" />
                    <ColorAttrRow title="声優名文字色" :color="actorStore.detail.Body.ActorTextColor" />
                    <ColorAttrRow title="声優名枠色" :color="actorStore.detail.Body.ActorOutlineColor" />
                    <DetailRow title="声優名枠幅" :value="actorStore.detail.Body.ActorOutlineWidth.toString()" />
                    <ExtDataRow :ext="actorStore.detail.Body.ExtData" />
                    <EditAndDeleteRow :editFunc="showEditActor" deleteModalId="confirm-delete-actor" />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <ModalDialog
      id="confirm-add-actor"
      title="声優情報追加の確認"
      :notice="addNotice"
      :okFunc="addActorOK"
    />
    <ModalDialog
      id="confirm-update-actor"
      title="声優情報更新の確認"
      :notice="updateNotice"
      :okFunc="updateActorOK"
    />
    <ModalDialog
      id="confirm-delete-actor"
      title="声優情報削除の確認"
      :notice="deleteNotice"
      :okFunc="deleteActorOK"
    />
  </div>
</template>
