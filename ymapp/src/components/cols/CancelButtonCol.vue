<script setup lang="ts">
import { defineProps } from "vue";

const props = defineProps({
  cancelFunc: { type: Function, required: true },
});
</script>

<template>
  <div class="col">
    <button v-on:click="props.cancelFunc()" class="btn btn-secondary full_fit">キャンセル</button>
  </div>
</template>