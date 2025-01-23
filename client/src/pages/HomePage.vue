<script setup>
import { restaurantsService } from '@/services/RestaurantsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { onMounted } from 'vue';

onMounted(() => {
  getRestaurants()
})

async function getRestaurants() {
  try {
    await restaurantsService.getRestaurants()
  } catch (error) {
    Pop.meow(error)
    logger.error('[GETTING RESTAURANTS]', error.message)
  }
}
</script>

<template>
  <div class="container-fluid">
    <section class="row">

    </section>
  </div>
</template>

<style scoped lang="scss"></style>
