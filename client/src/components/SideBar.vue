<script setup>
import { computed } from 'vue';
import ReportModal from './ReportModal.vue';
import { AppState } from '@/AppState.js';

const account = computed(() => AppState.account)

</script>


<template>
  <div class="p-1 sticky-top">
    <div class="bg-success text-light">
      <div class="text-center">
        <b class="fs-1">HELP</b>
      </div>
      <div class="text-center">
        <i class="mdi mdi-rodent fs-1"></i>
      </div>
    </div>
    <div class="text-center text-success mb-3">
      <b>food reports</b>
    </div>
    <div>
      <button v-if="account" type="button" class="btn btn-success w-100" data-bs-toggle="modal"
        data-bs-target="#reportModal">
        Report
      </button>
    </div>
  </div>

  <ReportModal />
</template>


<style lang="scss" scoped></style>