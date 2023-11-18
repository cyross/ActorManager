<script setup lang="ts">
import { defineProps } from 'vue'

const props = defineProps({
  text: String
})
</script>

<template>
  <div class="row py-1 mini_height">
    <div class="col">
      <div class="d-flex align-items-center">{{ props.text }}</div>
    </div>
  </div>
</template>
