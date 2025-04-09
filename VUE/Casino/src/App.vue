<script setup>
import { RouterLink, RouterView } from 'vue-router'

</script>

<template>
 

 <div class="container">
 
        <nav class="text-center">
          <RouterLink class="btn btn-outline-success m-2" to="/Home">Lottók</RouterLink>
          <RouterLink class="btn btn-outline-success m-2" to="/jatek">Játék</RouterLink>          
        </nav>  
            <RouterView />           
        </div> 

  
</template>


