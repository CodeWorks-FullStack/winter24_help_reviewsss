<script setup>
import { AppState } from '@/AppState.js';
import { reportsService } from '@/services/ReportsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { computed, ref } from 'vue';

const restaurants = computed(() => AppState.restaurants.filter(restaurant => restaurant.creatorId != AppState.account?.id))

const editableReportData = ref({
  title: '',
  body: '',
  score: 3,
  restaurantId: 0,
  imgUrl: ''
})

async function createReport() {
  try {
    await reportsService.createReport(editableReportData.value)
    editableReportData.value = {
      title: '',
      body: '',
      score: 3,
      restaurantId: 0,
      imgUrl: ''
    }
    Modal.getInstance('#reportModal').hide()
  } catch (error) {
    Pop.meow(error)
    logger.error('[CREATING REPORT]', error.message)
  }
}
</script>


<template>
  <form @submit.prevent="createReport()">
    <div class="mb-3">
      <select v-model="editableReportData.restaurantId" class="form-select" aria-label="Pick a restaurant" required>
        <option :value="0" disabled selected>Select a restaurant</option>
        <option v-for="restaurant in restaurants" :key="'reportFrom' + restaurant.id" :value="restaurant.id">
          {{ restaurant.name }}
        </option>
      </select>
    </div>
    <div class="mb-3">
      <label for="reportTitle" class="form-label">Title of Report</label>
      <input v-model="editableReportData.title" type="text" class="form-control" id="reportTitle"
        placeholder="Report Title..." required maxlength="255">
      <div id="reportTitleHelp" class="form-text">Make it eye catching...</div>
    </div>
    <div class="mb-3">
      <label for="reportTitle" class="form-label">Image of Report</label>
      <input v-model="editableReportData.imgUrl" type="url" class="form-control" id="reportTitle"
        placeholder="Report Image..." maxlength="3000">
      <div id="reportTitleHelp" class="form-text">Make it a picture...</div>
    </div>
    <div class="mb-3">
      <label for="reportScore" class="form-label">
        Score for report: {{ editableReportData.score }}
      </label>
      <input v-model="editableReportData.score" type="range" class="form-range" id="reportScore" min="1" max="5"
        required>
    </div>
    <div class="mb-3">
      <label for="reportBody" class="form-label">Body of Report</label>
      <textarea v-model="editableReportData.body" class="form-control" id="reportBody" rows="3"
        maxlength="2000"></textarea>
      <div id="reportBodyHelp" class="form-text">Make it juicy...</div>
    </div>
    <div class="d-flex justify-content-end gap-2">
      <button type="button" class="btn btn-outline-danger" data-bs-dismiss="modal">Close</button>
      <button :disabled="editableReportData.restaurantId == 0" type="submit" class="btn btn-success">Create
        Report</button>
    </div>
  </form>
</template>


<style lang="scss" scoped></style>