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
        <h1 class="text-success"><b>{{ restaurant.name }}</b></h1>
        <div class="restaurant-card">
          <img :src="restaurant.imgUrl" :alt="'A picture of ' + restaurant.name" class="restaurant-img">
          <div class="p-3">
            <p class="mb-5">{{ restaurant.description }}</p>
            <div class="d-md-flex justify-content-between align-items-center">
              <div class="d-flex gap-5">
                <div class="d-flex align-items-center">
                  <i class="mdi mdi-account-multiple-outline fs-1 text-success"></i>
                  <span><b>{{ restaurant.visits }}</b> recent visits</span>
                </div>
                <div class="d-flex align-items-center">
                  <i class="mdi mdi-file-document fs-1 text-success"></i>
                  <span><b>0</b> reports</span>
                </div>
              </div>
              <div class="d-flex gap-5">
                <button class="btn btn-success fs-5">
                  <i class="mdi mdi-door-open"></i>
                  Re-Open
                </button>
                <button class="btn btn-danger fs-5">
                  <i class="mdi mdi-delete-forever"></i>
                  Delete
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped>
.restaurant-img {
  width: 100%;
  height: 40dvh;
  object-fit: cover;
}
</style>