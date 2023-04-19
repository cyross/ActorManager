<script setup lang="ts">
import { defineProps, computed } from "vue";
import type { PropType } from "vue";

import { useColorStore } from "../../stores/colors";

import type { ActorColorInfo } from "../../types/actor";

import Col4TitleColumn from "../cols/Col4TitleCol.vue";

const colorsStore = useColorStore();

const isSelectedNamed = (type: string) => {
  return type === "named";
};

const isSelectedRgb = (type: string) => {
  return type === "rgb";
};

const props = defineProps({
  title: { type: String, required: true },
  name: { type: String, required: true },
  modelValue: { type: Object as PropType<ActorColorInfo>, required: true },
  updateNameFunc: { type: Function, required: true },
  updateRgbFunc: { type: Function, required: true },
  changeCheckFunc: { type: Function, required: true },
});

const colorNames = computed<Array<string>>(() => {
  return colorsStore.names;
});
</script>

<template>
  <div class="row">
    <Col4TitleColumn :title="props.title" />
    <div class="col-4">
      <form>
        <div class="input-group">
          <div class="container">
            <div class="row">
              <div class="col-3">
                <input
                  type="radio"
                  name="{{ props.name }}"
                  :value="props.modelValue.Type"
                  :checked="isSelectedNamed(props.modelValue.Type)"
                  @change="changeCheckFunc($event.target)"
                />
                名前
              </div>
              <div class="col">
                <select
                  :value="modelValue.Name"
                  @change="updateNameFunc($event.target)"
                >
                  <option
                    v-for="(option, index) in colorNames"
                    :key="index"
                  >
                    {{ option }}
                  </option>
                </select>
              </div>
            </div>
            <div class="row">
              <div class="col-3">
                <input
                  type="radio"
                  name="{{ props.name }}"
                  :value="props.modelValue.Type"
                  :checked="isSelectedRgb(props.modelValue.Type)"
                  @change="changeCheckFunc($event.target)"
                />
                RGB
              </div>
              <div class="col">
                <input
                  type="color"
                  class="form-control form-control-color"
                  :value="props.modelValue.Rgb"
                  @change="updateRgbFunc($event.target)"
                />
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>
