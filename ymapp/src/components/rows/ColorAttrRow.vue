<script setup lang="ts">
import { defineProps } from 'vue'
import { useColorStore } from '../../stores/colors'
import Col3TitleColumn from '../cols/Col3TitleCol.vue'

const colorStore = useColorStore()

const props = defineProps({
  title: String,
  color: String
})
</script>

<template>
  <div class="row py-1">
    <Col3TitleColumn :title="props.title" />
    <div class="col">
      <span v-bind:style="{ color: colorStore.strToColor(props.color) }">■</span>
      {{ props.color }}
    </div>
  </div>
</template>
