<script setup>
import { AppState } from '@/AppState.js';
import { restaurantsService } from '@/services/RestaurantsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const restaurant = computed(() => AppState.activeRestaurant)

const route = useRoute()

onMounted(() => {
  getRestaurantById()
})

async function getRestaurantById() {
  try {
    const restaurantId = route.params.restaurantId
    await restaurantsService.getRestaurantById(restaurantId)
  } catch (error) {
    Pop.meow(error)
    logger.error('[GETTING RESTAURANT BY ID]', error.message)
  }
}
</script>


<template>
  <div v-if="restaurant" class="container-fluid">
    <section class="row">
      <div class="col-12">
        <h1>{{ restaurant.name }}</h1>
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped></style>