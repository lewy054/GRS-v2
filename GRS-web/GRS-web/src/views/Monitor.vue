<template>
  <v-card>
    <Breadcrumbs :breadCrumbsItems="breadCrumbsItems"/>
  </v-card>
  <h1>Monitor</h1>
</template>

<script setup lang="ts">
import Breadcrumbs from "../components/breadcrumbs.vue";

const breadCrumbsItems = [
  {
    text: 'Home',
    disabled: false,
    href: '/',
  },
  {
    text: 'Monitor',
    disabled: true,
    href: 'monitor',
    color: "#FF006E",},
];
</script>

<style scoped>

</style>