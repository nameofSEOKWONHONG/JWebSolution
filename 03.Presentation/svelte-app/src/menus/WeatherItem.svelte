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
</article>