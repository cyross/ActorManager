<script setup lang="ts">
import { useNoticeAlertStore } from "../../stores/alert";

const noticeAlertStore = useNoticeAlertStore();
</script>

<template>
  <div v-show="noticeAlertStore.visible" class="row">
    <div class="col">
      <div class="alert alert-info show">
        <div class="container">
          <div class="row">
            <div class="col">{{ noticeAlertStore.message }}</div>
            <div class="col-1">
              <button v-on:click="noticeAlertStore.hide()" type="button" class="btn btn-info">
                <i class="bi-x-square"></i>
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
