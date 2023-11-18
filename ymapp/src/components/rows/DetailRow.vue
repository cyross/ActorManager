<script setup lang="ts">
import { defineProps } from 'vue'
import Col3TitleColumn from '../cols/Col3TitleCol.vue'

const props = defineProps({
  title: String,
  value: String
})
</script>

<template>
  <div class="row py-1">
    <Col3TitleColumn :title="props.title" />
    <div class="col">{{ props.value }}</div>
  </div>
</template>
