<script>
    import Button from '@smui/button';

    let count = 0;
    // the `$:` means 're-run whenever these values change'
    $: if (count >= 10) {
		alert(`count is dangerously high!`);
		count = 9;
	}
    function counterClick() {
        count = count + 1;
    }
</script>

<h1>Counter</h1>

<Button on:click={counterClick}>
    Click me
</Button>
<p>{count}</p>