<script setup lang="ts">
import type { PropType } from 'vue'
import { defineProps, computed } from 'vue'
import Col3TitleColumn from '../cols/Col3TitleCol.vue'

const props = defineProps({
  title: { type: String, required: true },
  list: { type: Array as PropType<string[]>, required: true }
})

const hasElements = computed(() => {
  return props.list.length > 0
})
</script>

<template>
  <div class="row py-1">
    <Col3TitleColumn :title="props.title" />
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
