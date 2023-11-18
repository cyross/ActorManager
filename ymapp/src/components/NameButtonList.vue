<script setup lang="ts">
import { defineProps } from 'vue'

import type { Names } from '../types/names'

const props = defineProps({
  names: { type: Array<Names>, required: true },
  showFunc: { type: Function, required: true }
})
</script>

<template>
  <div class="container">
    <div class="row overflow-auto name-list">
      <div class="col">
        <ul class="list-group">
          <li v-for="data in props.names" v-bind:key="data.Id" class="list-group-item">
            <button
              v-on:click="showFunc(data.Id)"
              type="button"
              class="btn btn-outline-primary btn-sm full_fit"
            >
              {{ data.Name }}
            </button>
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>
