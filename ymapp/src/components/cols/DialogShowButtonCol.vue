<script setup lang="ts">
import { defineProps, computed } from 'vue'
import type { ComputedRef } from 'vue'

const props = defineProps({
  id: { type: String, required: true },
  title: { type: String, required: true },
  variant: { type: String, required: true }
})

const id: ComputedRef<string> = computed(() => {
  return '#' + props.id
})

const btnClass: ComputedRef<string> = computed(() => {
  return 'btn-' + props.variant
})
</script>

<template>
  <div class="col-auto">
    <button
      type="button"
      data-bs-toggle="modal"
      :data-bs-target="id"
      class="btn full_fit"
      :class="btnClass"
    >
      {{ props.title }}
    </button>
  </div>
</template>
