<template>
  <v-breadcrumbs :items="props.breadCrumbsItems">
    <template v-slot:divider>//</template>
  </v-breadcrumbs>
</template>

<script setup lang="ts">
import {defineProps} from "vue";

const props = defineProps({
  breadCrumbsItems: Array<Object>
});
</script>

<style scoped>

</style>