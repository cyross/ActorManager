<script setup lang="ts">
import { defineProps, computed } from 'vue'
import type { PropType } from 'vue'

import { useColorStore } from '../../stores/colors'

import type { ActorColorInfo } from '../../types/actor'

import Col2TitleColumn from '../cols/Col2TitleCol.vue'

const colorsStore = useColorStore()

const isSelectedNamed = (type: string) => {
  return type === 'named'
}

const isSelectedRgb = (type: string) => {
  return type === 'rgb'
}

const props = defineProps({
  title: { type: String, required: true },
  name: { type: String, required: true },
  modelValue: { type: Object as PropType<ActorColorInfo>, required: true },
  updateNameFunc: { type: Function, required: true },
  updateRgbFunc: { type: Function, required: true },
  changeCheckFunc: { type: Function, required: true }
})

const colorNames = computed<Array<string>>(() => {
  return colorsStore.names
})

const checkIdNamed = computed<string>(() => `input-radio-name-${props.name}`)
const checkIdRgb = computed<string>(() => `input-radio-rgb-${props.name}`)
</script>

<template>
  <div class="row py-1">
    <Col2TitleColumn :title="props.title" />
    <div class="col">
      <form>
        <div class="container">
          <div class="row">
            <div class="col-auto align-self-center">
              <div class="row">
                <div class="col-auto align-self-center">
                  <div class="input-group">
                    <input
                      :id="checkIdNamed"
                      type="radio"
                      class="form-check-input"
                      name="{{ props.name }}"
                      :value="props.modelValue.Type"
                      :checked="isSelectedNamed(props.modelValue.Type)"
                      @change="changeCheckFunc($event.target)"
                    />
                    <label class="form-check-label" :for="checkIdNamed">&nbsp;名前</label>
                  </div>
                </div>
                <div class="col-auto align-self-center">
                  <div class="input-group">
                    <select
                      class="form-select-sm"
                      :value="modelValue.Name"
                      @change="updateNameFunc($event.target)"
                    >
                      <option v-for="(option, index) in colorNames" :key="index">
                        {{ option }}
                      </option>
                    </select>
                  </div>
                </div>
              </div>
            </div>
            <div class="col align-self-center">
              <div class="row">
                <div class="col-auto align-self-center">
                  <div class="input-group">
                    <input
                      :id="checkIdRgb"
                      type="radio"
                      class="form-check-input"
                      name="{{ props.name }}"
                      :value="props.modelValue.Type"
                      :checked="isSelectedRgb(props.modelValue.Type)"
                      @change="changeCheckFunc($event.target)"
                    />
                    <label class="form-check-label" :for="checkIdRgb">&nbsp;RGB</label>
                  </div>
                </div>
                <div class="col align-self-center">
                  <div class="input-group">
                    <input
                      type="color"
                      class="form-control-sm form-control-color"
                      :value="props.modelValue.Rgb"
                      @change="updateRgbFunc($event.target)"
                    />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>
