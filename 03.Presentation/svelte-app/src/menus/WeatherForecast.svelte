<script>
    // svelte 패키지에서 해당 라이프사이클을 구현하면 됩니다.
    import { onMount, onDestroy, beforeUpdate, afterUpdate, tick } from 'svelte'
    import WeatherItem from "./WeatherItem.svelte";

    let weatherItems;

    onMount(async () => {
        fetch("https://localhost:5001/api/WeatherForecast/Gets")
        .then(response => response.json())
        .then(data => {
            console.log(data);
            weatherItems = data;
            console.log(data[0].date);
        }).catch(error => {
            console.log(error);
            return [];
        });
    });

    onDestroy(async () => {
        console.log('onDestroy');
    });

    beforeUpdate(async () => {
        console.log('beforeUpdate');
        await tick(); // tick : 언제든지 호출가능 + 컴포넌트에 변경사항이 완료가 되었을때 Promise() 반환
        console.log('tick()..');
    });

    afterUpdate(async () => {
        console.log('afterUpdate');
    });
</script>

<style>
    .loading {
      opacity: 0;
      animation: 0.4s 0.8s forwards fade-in;
    }
    @keyframes fade-in {
      from { opacity: 0; }
      to { opacity: 1; }
    }
    li {
      list-style-type: georgian;
    }
  </style>

<h1>WeatherForecast</h1>

{#if weatherItems}
  {#each weatherItems as item }
    <ul>
      <li>    
          <WeatherItem {item}/>
        <!-- <article>
            <h1>{item.id}</h1>
            <small>
                date: <b>{item.date}</b>   
            </small><br/>
            <small>
                temperatureC: <b>{item.temperatureC}</b>
            </small><br/>
            <small>
                summary: <b>{item.summary}</b>
            </small>
        </article> -->
      </li>
    </ul>
  {/each}
{:else}
  <p class="loading">loading...</p>
{/if}