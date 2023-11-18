<script setup lang="ts">
import { defineProps } from 'vue'

const props = defineProps({
  showFunc: { type: Function, required: true }
})
</script>

<template>
  <div class="row py-1">
    <div class="col">
      <button v-on:click="props.showFunc()" type="button" class="btn btn-primary full_fit">
        新規作成
      </button>
    </div>
  </div>
</template>
