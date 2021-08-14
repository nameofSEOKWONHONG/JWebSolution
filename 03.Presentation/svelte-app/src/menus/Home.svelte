<script>
	let name = '';
</script>

<h1>Home</h1>

<input bind:value={name} placeholder="enter your name">
<p>Hello {name || 'stranger'}!</p>