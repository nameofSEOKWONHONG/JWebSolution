<script>
    // create a prop
    export let item;
</script>

<style>
  article {
    margin: 0 0 1em 0;
  }
  h1 {
    font-size: 1.4em;
    margin: 0;
    display: block;
  }
</style>

<article>
    <h1>{item.ID}</h1>
    <small>
        date: <b>{item.Date}</b>   
    </small><br/>
    <small>
        temperatureC: <b>{item.TemperatureC}</b>
    </small><br/>
    <small>
        summary: <b>{item.Summary}</b>
    </small>
</article>