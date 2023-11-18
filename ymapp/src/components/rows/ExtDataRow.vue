<script setup lang="ts">
import type { PropType } from 'vue'
import { defineProps, computed } from 'vue'

import type { Dictionary } from '../../types/common'

import Col3TitleColumn from '../cols/Col3TitleCol.vue'

const props = defineProps({
  ext: { type: Object as PropType<Dictionary<string>>, required: true }
})

const extData = computed(() => {
  return props.ext
})

const isEmpty = computed(() => {
  return Object.keys(props.ext).length === 0
})
</script>

<template>
  <div class="row py-1">
    <Col3TitleColumn title="拡張情報" />
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
        </div>
      </div>
    </div>
  </div>
</template>
