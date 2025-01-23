<script setup>
import { Report } from '@/models/Report.js';

defineProps({
  report: { type: Report, required: true }
})

</script>


<template>
  <p>{{ report.title }}</p>
</template>


<style lang="scss" scoped></style>