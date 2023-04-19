<script setup lang="ts">
import { useColorStore } from "../../stores/colors";

const colorStore = useColorStore();
</script>

<template>
  <div class="col">
    <div
      v-if="colorStore.detail.Index === -1"
      class="d-flex detail_box"
    >
      <p>選択がされていません</p>
    </div>
    <div
      v-else
      class="d-flex detail_box"
    >
      <div>
        <p>
          <span
            v-bind:style="{ color: colorStore.detail.Body.Hex }"
            class="detail_color_box"
            >■</span
          >
        </p>
        <ul>
          <li>名前: {{ colorStore.detail.Body.Name }}</li>
          <li>
            {{ colorStore.detail.Body.Hex }}&nbsp; (
            {{ colorStore.detail.Body.R }},&nbsp;
            {{ colorStore.detail.Body.G }},&nbsp;
            {{ colorStore.detail.Body.B }}
            )
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>
