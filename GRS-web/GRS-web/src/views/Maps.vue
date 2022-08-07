<template>
  <v-card>
    <Breadcrumbs :breadCrumbsItems="breadCrumbsItems"/>
  </v-card>
  <h1>Maps</h1>
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
    text: 'Maps',
    disabled: true,
    href: 'maps',
    color: "#FF006E",},
];
</script>

<style scoped>

</style>