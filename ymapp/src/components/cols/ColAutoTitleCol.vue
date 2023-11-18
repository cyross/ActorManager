<script setup lang="ts">
import { defineProps } from 'vue'

const props = defineProps({
  title: String
})
</script>

<template>
  <div class="col-auto">{{ props.title }}</div>
</template>
