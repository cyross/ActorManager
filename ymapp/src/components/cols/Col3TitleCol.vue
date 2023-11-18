<script setup lang="ts">
import { defineProps } from 'vue'

const props = defineProps({
  title: String
})
</script>

<template>
  <div class="col-3">{{ props.title }}</div>
</template>
