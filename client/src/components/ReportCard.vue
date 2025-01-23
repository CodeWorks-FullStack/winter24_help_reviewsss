<script setup>
import { Report } from '@/models/Report.js';

defineProps({
  report: { type: Report, required: true }
})

</script>


<template>
  <div class="restaurant-card p-3 mb-3">
    <div class="container">
      <div class="row justify-content-end">
        <div class="col-6 text-center">
          <h3><b class="text-success">{{ report.title }}</b></h3>
        </div>
        <div class="col-3">
          <div class="d-flex gap-2 justify-content-end">
            <div class="text-end">
              <p><b>{{ report.creator.name }}</b></p>
              <p><b>{{ report.createdAt.toLocaleDateString() }}</b></p>
            </div>
            <img :src="report.creator.picture" :alt="'A picture of ' + report.creator.name" class="creator-img">
          </div>
        </div>
        <div v-if="report.imgUrl" class="col-12 text-center">
          <img :src="report.imgUrl" :alt="'Report picture for ' + report.title" class="img-fluid">
        </div>
        <div class="col-12">
          <p>{{ report.body }}</p>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.creator-img {
  height: 8dvh;
  aspect-ratio: 1/1;
  object-fit: cover;
  object-position: center;
  border-radius: 50%;
}
</style>