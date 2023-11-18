<script setup lang="ts">
import { ref, onMounted } from 'vue'
import type { Ref } from 'vue'
import type { AxiosResponse } from 'axios'

import type { ColorSpec } from '../types/color'

import { getColorSpecs } from '../logics/callApi/colorSpecs'

import AlertsComponent from '../components/AlertsComponent.vue'

const specs: Ref<Array<ColorSpec>> = ref([])

const loaded: Ref<boolean> = ref(false)

onMounted(() => {
  getColorSpecs((response: AxiosResponse) => {
    specs.value = response.data.Specs
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
      <div class="row py-4">
        <div class="col menu_title">色名リスト</div>
      </div>
      <div class="row py-4">
        <div class="col">
          <ul class="list-group">
            <li
              v-for="data in specs"
              v-bind:key="data.Id"
              class="list-group-item color-list-element"
            >
              <span v-bind:style="{ color: data.Hex }" class="preview_color_box">■</span>&nbsp;{{
                data.Name
              }}
              / {{ data.Hex }}
            </li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>
