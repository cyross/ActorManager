<script setup lang="ts">
import type { PropType } from "vue";
import { defineProps } from "vue";

import { useColorStore } from "../../stores/colors";

import type { ColorSpec } from "../../types/color";

const colorStore = useColorStore();

const props = defineProps({
  specs: { type: Object as PropType<Array<ColorSpec>>, required: true },
});

const showColorDetail = (id: number) => {
  const spec: ColorSpec | undefined = props.specs.find(
    (spec: ColorSpec) => spec.Id === id
  );

  if (spec === undefined) {
    return;
  }

  colorStore.setDetail(id, spec);
};
</script>

<template>
  <div class="col-4 overflow-auto full_height">
    <ul class="list-group">
      <li
        v-for="data in colorStore.specs"
        v-bind:key="data.Id"
        class="list-group-item"
      >
        <button
          v-on:click="showColorDetail(data.Id)"
          type="button"
          class="btn btn-outline-primary color-button"
        >
          <span
            v-bind:style="{ color: data.Hex }"
            class="preview_color_box"
            >■</span
          >&nbsp;
          {{ data.Name }}
        </button>
      </li>
    </ul>
  </div>
</template>
