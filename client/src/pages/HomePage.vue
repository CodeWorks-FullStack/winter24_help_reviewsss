<script setup>
import { AppState } from '@/AppState.js';
import RestaurantCard from '@/components/RestaurantCard.vue';
import { restaurantsService } from '@/services/RestaurantsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const restaurants = computed(() => AppState.restaurants)

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
      <div v-for="restaurant in restaurants" :key="restaurant.id" class="col-md-4">
        <RestaurantCard :restaurant="restaurant" />
      </div>
    </section>
  </div>
</template>

<style scoped lang="scss"></style>
