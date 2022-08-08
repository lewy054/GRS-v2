<template>
  <v-card color="rgb(22,31,44, 0.7)">
    <Breadcrumbs :breadCrumbsItems="breadCrumbsItems"/>
    <v-container>
      <v-row class="justify-center">
        <router-link to="/maps">
          <v-btn class="btn-submit mr-2" append-icon="mdi-format-list-bulleted-square">MAPS</v-btn>
        </router-link>
        <router-link to="/testers">
          <v-btn class="btn-blue" append-icon="mdi-account-group">TESTERS</v-btn>
        </router-link>
        <router-link to="/upload">
          <v-btn class="btn-orange ml-2" append-icon="mdi-cloud-upload">UPLOAD</v-btn>
        </router-link>
      </v-row>
    </v-container>
    <router-view></router-view>
  </v-card>
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
    color: "#FF006E",
  },
];
</script>

<style scoped>
.btn-submit {
  color: #fff;
  background-color: #242433;
  border: 1px solid #5BCE00;
}

.btn-submit:hover {
  background-color: #5BCE00;
  color: #fff;
}

.btn-blue {
  color: #fff;
  background-color: #242433;
  border: 1px solid #3A86FF;
}

.btn-blue:hover {
  background-color: #3A86FF;
  color: #fff;
}

.btn-orange {
  color: #fff;
  background-color: #242433;
  border: 1px solid #FB5607;
}

.btn-orange:hover {
  background-color: #FB5607;
  color: #fff;
}
</style>