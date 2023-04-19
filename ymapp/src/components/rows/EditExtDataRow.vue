<script setup lang="ts">
import type { Ref, PropType } from "vue";
import { ref, defineProps, computed } from "vue";

import type { Dictionary } from "../../types/common";

import { useErrorAlertStore } from "../../stores/alert";

import Col4TitleColumn from "../cols/Col4TitleCol.vue";
import EmptyRow from "./EmptyRow.vue";

const errorAlertStore = useErrorAlertStore();

const extKey: Ref<string> = ref("");
const extValue: Ref<string> = ref("");

const getInput = (event: Event) => {
  if (event.target instanceof HTMLInputElement) {
    return event.target.value;
  }

  return "";
};

const props = defineProps({
  ext: { type: Object as PropType<Dictionary<string>>, required: true },
  addFunc: { type: Function, required: true },
  removeFunc: { type: Function, required: true },
});

const extData = computed(() => {
  return props.ext;
});

const isEmpty = computed(() => {
  return Object.keys(props.ext).length === 0;
});

const add = (key: string, value: string) => {
  key = key.trim();

  if (key === "") {
    errorAlertStore.show("キーが空白です");
    return;
  }

  if (Object.keys(props.ext).indexOf(key) >= 0)
  {
    errorAlertStore.show("キーが既に存在しています");
    return;
  }

  props.addFunc(key, value);

  extKey.value = "";
  extValue.value = "";
}

const remove = (key: string) => {
  if (Object.keys(props.ext).indexOf(key) < 0) {
    errorAlertStore.show("存在していないキーです");
    return;
  }

  props.removeFunc(key);
}
</script>

<template>
  <div class="row">
    <Col4TitleColumn title="拡張情報" />
    <div class="col">
      <div v-if="isEmpty" class="container">
        <div class="row">
          <div class="col">なし</div>
        </div>
      </div>
      <div v-else v-for="(value, key) in extData" v-bind:key="key" class="container">
        <div class="row">
          <div class="col">{{ key }}</div>
          <div class="col">{{ value }}</div>
          <div class="col">
            <button
              v-on:click="remove(key.toString())"
              type="button"
              class="btn btn-warning full_fit"
            >
              削除
            </button>
          </div>
        </div>
      </div>
      <EmptyRow />
      <div class="container">
        <div class="row">
          <div class="col">
            <input type="text" :value="extKey" @input="extKey = getInput($event)" class="form-control" placeholder="キー" />
          </div>
          <div class="col">
            <input type="text" :value="extValue" @input="extValue = getInput($event)" class="form-control" placeholder="値" />
          </div>
          <div class="col">
            <button
              v-on:click="add(extKey, extValue)"
              type="button"
              class="btn btn-primary full_fit"
            >
              追加
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
