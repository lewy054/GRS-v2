<template>
  <v-card color="rgb(22,31,44, 0.7)">
    <Breadcrumbs :breadCrumbsItems="breadCrumbsItems"/>
    <v-text-field hide-details label="Search" append-inner-icon="mdi-magnify"/>
    <v-card color="rgb(22,31,44, 0)">
      <v-list lines="three" style="background-color:rgb(22,31,44, 0)">
        <v-list-subheader>Reports
        </v-list-subheader>
        <router-link to="/forum/report-player" class="reset-a">
          <v-list-item style="padding-bottom: 0;"
                       title="Report Player"
          >
            <template v-slot:prepend>
              <v-avatar>
                <v-icon size="x-large" color="white">mdi-emoticon-angry</v-icon>
              </v-avatar>
            </template>

            <template v-slot:subtitle>
              <span>Report a Player to punish him.</span>
              <v-divider class="mt-3 mb-2 "/>
              <span>
              Recent
              <span style="color: blue" class="font-weight-bold">
                Thread Title
              </span>
            </span>
              <v-divider color="grey" class="mb-2 mt-2"/>
            </template>
          </v-list-item>
        </router-link>

        <router-link to="/forum/report-staff" class="reset-a">
          <v-list-item style="padding-bottom: 0;"
                       title="Report Staff"
          >
            <template v-slot:prepend>
              <v-avatar>
                <v-icon size="x-large" color="white">mdi-emoticon-cry</v-icon>
              </v-avatar>
            </template>

            <template v-slot:subtitle>
              <span>Report an Admin to punish him.</span>
              <v-divider class="mt-3 mb-2 "/>
              <span>
              Recent
              <span style="color: blue" class="font-weight-bold">
                Thread Title
              </span>
            </span>
              <v-divider color="grey" class="mb-2 mt-2"/>
            </template>
          </v-list-item>
        </router-link>

        <router-link to="/forum/report-bug" class="reset-a">
          <v-list-item style="padding-bottom: 0;"
                       title="Report Bug"
          >
            <template v-slot:prepend>
              <v-avatar>
                <v-icon size="x-large" color="white">mdi-bug</v-icon>
              </v-avatar>
            </template>

            <template v-slot:subtitle>
              <span>Lets us know if something is not working as it should!</span>
              <v-divider class="mt-3 mb-2 "/>
              <span>
              Recent
              <span style="color: blue" class="font-weight-bold">
                Thread Title
              </span>
            </span>
              <v-divider color="grey" class="mb-2 mt-2"/>
            </template>
          </v-list-item>
        </router-link>
      </v-list>
    </v-card>

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
    text: 'Forum',
    disabled: true,
    href: 'forum',
    color: "#FF006E",
  },
];
</script>

<style scoped>

</style>