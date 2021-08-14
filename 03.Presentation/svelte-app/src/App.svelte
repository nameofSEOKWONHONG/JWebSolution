<script>
	import Home from "./menus/Home.svelte";
	import Counter from "./menus/Counter.svelte";
	import WeatherForecast from "./menus/WeatherForecast.svelte";
	export let name;
	export let menu = 1;
</script>

<main>
	<ul id="menu">
		<li><a href="/" on:click|preventDefault={() => (menu = 1)}>Home</a></li> |
		<li><a href="/" on:click|preventDefault={() => (menu = 2)}>Counter</a></li> |
		<li><a href="/" on:click|preventDefault={() => (menu = 3)}>WeatherForecast</a></li>
	</ul>

	{#if menu === 1}
		<Home />
	{:else if menu === 2}
		<Counter />
	{:else if menu === 3}
	    <WeatherForecast/>
	{:else}
		<h1>
			Page Not Found
		</h1>
	{/if}

	<h1>Hello {name}!</h1>
	<p>Visit the <a href="https://svelte.dev/tutorial">Svelte tutorial</a> to learn how to build Svelte apps.</p>
</main>

<style>
	ul#menu li{
		display : inline;
	}

	main {
		text-align: center;
		padding: 1em;
		max-width: 240px;
		margin: 0 auto;
	}

	h1 {
		color: #ff3e00;
		text-transform: uppercase;
		font-size: 4em;
		font-weight: 100;
	}

	@media (min-width: 640px) {
		main {
			max-width: none;
		}
	}
</style>