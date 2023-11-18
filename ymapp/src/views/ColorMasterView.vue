<script setup lang="ts">
import type { Ref } from 'vue'
import { ref, onMounted } from 'vue'
import type { AxiosResponse } from 'axios'

import { useColorStore } from '../stores/colors'

import { getColorSpecs } from '../logics/callApi/colorSpecs'

import AlertsComponent from '../components/AlertsComponent.vue'
import ColorButtonCol from '../components/cols/ColorButtonCol.vue'
import ColorDetailCol from '../components/cols/ColorDetailCol.vue'

const colorStore = useColorStore()

const loaded: Ref<Boolean> = ref(false)

onMounted(() => {
  loaded.value = false

  getColorSpecs((response: AxiosResponse) => {
    colorStore.setSpecs(response.data.Specs)
    colorStore.setColorNames()
    colorStore.setNameToColor()

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
      <div class="row py-1">
        <ColorButtonCol :specs="colorStore.specs" />
        <ColorDetailCol />
      </div>
    </div>
  </div>
</template>
