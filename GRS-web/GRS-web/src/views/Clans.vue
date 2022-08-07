<template>
  <v-card>
    <Breadcrumbs :breadCrumbsItems="breadCrumbsItems"/>
  </v-card>
  <h1>Clans</h1>
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
    text: 'Clans',
    disabled: true,
    href: 'clans',
    color: "#FF006E",},
];
</script>

<style scoped>

</style>