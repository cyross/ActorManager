<script setup lang="ts">
import { defineProps } from "vue";

const props = defineProps({
  id: { type: String, required: true },
  title: { type: String, required: true },
  notice: { type: String, required: true },
  okFunc: { type: Function, required: true },
});

const closeBtnId = props.id + "-close";

const onClickOk = () => {
  const closeBtn = document.getElementById(closeBtnId);
  closeBtn?.click();
  props.okFunc();
};
</script>

<template>
  <div
    class="modal"
    :id="id"
    tabindex="-1"
    role="dialog"
    aria-labelledby="basicModal"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">{{ props.title }}</h5>
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
        </div>
        <div class="modal-body">
          <p>{{ props.notice }}</p>
        </div>
        <div class="modal-footer">
          <button
            type="button"
            :id="closeBtnId"
            class="btn btn-secondary"
            data-bs-dismiss="modal"
          >
            Close
          </button>
          <button
            v-on:click="onClickOk()"
            type="button"
            class="btn btn-primary"
          >
            OK
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
