<script setup lang="ts">
import type { PropType } from "vue";
import { defineProps, computed } from "vue";
import Col6TitleColumn from "../cols/Col6TitleCol.vue";

const props = defineProps({
  title: { type: String, required: true },
  list: { type: Array as PropType<string[]>, required: true },
});

const hasElements = computed(() => {
  return props.list.length > 0;
});
</script>

<template>
  <div class="row">
    <Col6TitleColumn :title="props.title" />
    <div class="col">
      <span v-if="!hasElements">なし</span>
      <ul>
        <li v-for="(element, index) in props.list" v-bind:key="index">
          {{ element }}
        </li>
      </ul>
    </div>
  </div>
</template>
