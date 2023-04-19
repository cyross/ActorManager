<script setup lang="ts">
import { defineProps } from "vue";

import DialogShowButtonCol from "../cols/DialogShowButtonCol.vue";

const props = defineProps({
  id: { type: String, required: true },
  title: { type: String, required: true },
  variant: { type: String, required: true },
});
</script>

<template>
  <div class="row">
    <DialogShowButtonCol :id="props.id" :title="props.title" :variant="props.variant" />
  </div>
</template>
