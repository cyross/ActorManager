<script setup lang="ts">
import { defineProps, computed } from 'vue'
import type { ComputedRef } from 'vue'

const props = defineProps({
  editFunc: { type: Function, required: true },
  deleteModalId: { type: String, required: true }
})

const id: ComputedRef<string> = computed(() => {
  return '#' + props.deleteModalId
})
</script>

<template>
  <div class="row py-1">
    <div class="col-auto">
      <button v-on:click="props.editFunc()" type="button" class="btn btn-primary full_fit">
        編集
      </button>
    </div>
    <div class="col-auto">
      <button
        type="button"
        data-bs-toggle="modal"
        :data-bs-target="id"
        class="btn btn-danger full_fit"
      >
        削除
      </button>
    </div>
  </div>
</template>
