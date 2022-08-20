<template>
  <v-card color="rgb(22,31,44, 0.7)">
  <v-container>
    <v-text-field hide-details label="Search" class="rounded-xl" append-inner-icon="mdi-magnify"/>
  </v-container>
  <v-container>
    <v-expansion-panels>
      <v-expansion-panel>
        <v-expansion-panel-title expand-icon="mdi-plus" collapse-icon="mdi-minus">
          <v-avatar class="mr-3">
            <v-icon size="x-large" color="red">mdi-close</v-icon>
          </v-avatar>
          Test Map 1
          Author:User
          <v-divider/>
          <template v-slot:actions="{ expanded }">
            <v-icon size="x-large" color="blue" :icon="expanded ? 'mdi-chevron-up' : 'mdi-chevron-down'"></v-icon>
          </template>
        </v-expansion-panel-title>
        <v-expansion-panel-text>
          <span style="color: gray; font-size: 0.8em" class="font-weight-bold">Rejected 2 Hours Ago</span>
          <v-divider/>
          <span style="color: blue">~Lewy~: </span> Bad map
        </v-expansion-panel-text>
      </v-expansion-panel>

      <v-expansion-panel>
        <v-expansion-panel-title>
          <v-avatar class="mr-3">
            <v-icon size="x-large" color="green">mdi-check</v-icon>
          </v-avatar>
          Test Map 2
          <template v-slot:actions="{ expanded }">
            <v-icon size="x-large" color="blue" :icon="expanded ? 'mdi-chevron-up' : 'mdi-chevron-down'"></v-icon>
          </template>
        </v-expansion-panel-title>
        <v-expansion-panel-text>
          <span style="color: gray; font-size: 0.8em" class="font-weight-bold">Accepted 2 Hours Ago</span>
          <v-divider/>
          <span style="color: blue">~Lewy~: </span> Good map
        </v-expansion-panel-text>
      </v-expansion-panel>

      <v-expansion-panel>
        <v-expansion-panel-title disable-icon-rotate>
          <v-avatar class="mr-3">
            <v-icon size="x-large" color="red">mdi-close</v-icon>
          </v-avatar>
          Test Map 3
          <template v-slot:actions="{ expanded }">
            <v-icon size="x-large" color="blue" :icon="expanded ? 'mdi-chevron-up' : 'mdi-chevron-down'"></v-icon>
          </template>
        </v-expansion-panel-title>
        <v-expansion-panel-text>
          <span style="color: gray; font-size: 0.8em" class="font-weight-bold">Rejected 2 Hours Ago</span>
          <v-divider/>
          <span style="color: blue">~Lewy~: </span> Bad map
        </v-expansion-panel-text>
      </v-expansion-panel>
    </v-expansion-panels>
  </v-container>
  </v-card>
</template>

<script setup lang="ts">

</script>

<style scoped>

</style>