<script setup lang="ts">
import { callApi } from "../utils/apiCall";

import { useConfigStore } from "../stores/config";

import ModalDialog from "../components/dialogs/ModalDialog.vue";
import EmptyRow from "../components/rows/EmptyRow.vue";
import AlertsComponent from "../components/AlertsComponent.vue";
import DialogShowButtonRow from "../components/rows/DialogShowButtonRow.vue";

const configStore = useConfigStore();

const saveAllApi = `${configStore.apiBaseURL}/api/v1/SaveAll/`;
const saveVHApi = `${configStore.apiBaseURL}/api/v1/SaveVH/`;
const revertAllApi = `${configStore.apiBaseURL}/api/v1/ResetAll/`;

const saveAllOK = () => {
  callApi(saveAllApi, "YAMLファイルの保存に成功しました", "YAMLファイル保存エラー");
};

const saveVHOK = () => {
  callApi(saveVHApi, "VegasHelper YAMLファイルの保存に成功しました", "VegasHelper YAMLファイル保存エラー");
};

const revertAllOK = () => {
  callApi(revertAllApi, "データの巻き戻しに成功しました", "巻き戻しエラー");
};
</script>

<template>
  <div class="container main-view">
    <AlertsComponent />
    <DialogShowButtonRow id="confirm-save-all" variant="success" title="設定をYAMLに保存" />
    <EmptyRow />
    <DialogShowButtonRow id="confirm-save-vh" variant="success" title="設定をVegasHelper用のYAMLとして保存" />
    <EmptyRow />
    <DialogShowButtonRow id="confirm-revert-all" variant="danger" title="設定を初期状態に戻す" />
    <ModalDialog
      id="confirm-save-all"
      title="YAML保存の確認"
      notice="編集内容をYAMLとして保存・反映します。よろしいですか？"
      :okFunc="saveAllOK"
    />
    <ModalDialog
      id="confirm-save-vh"
      title="VegasHelper YAML保存の確認"
      notice="編集内容をVegasHelper用のYAMLとして保存・反映します。よろしいですか？"
      :okFunc="saveVHOK"
    />
    <ModalDialog
      id="confirm-revert-all"
      title="設定初期化の確認"
      notice="YAMLファイルを初期状態に戻します。よろしいですか？"
      :okFunc="revertAllOK"
    />
  </div>
</template>
