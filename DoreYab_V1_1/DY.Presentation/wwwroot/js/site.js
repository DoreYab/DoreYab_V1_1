// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
<script>
        // Mobile Menu Toggle
    const mobileMenuButton = document.getElementById('mobileMenuButton');
    const mobileMenu = document.getElementById('mobileMenu');

        mobileMenuButton.addEventListener('click', () => {
        mobileMenu.classList.toggle('hidden');
        });

    // Theme Toggle
    const themeToggle = document.getElementById('themeToggle');

        themeToggle.addEventListener('click', () => {
        document.documentElement.classList.toggle('dark');
    localStorage.setItem('theme', document.documentElement.classList.contains('dark') ? 'dark' : 'light');
        });

    // Check for saved theme preference
    if (localStorage.getItem('theme') === 'dark' || (!localStorage.getItem('theme') && window.matchMedia('(prefers-color-scheme: dark)').matches)) {
        document.documentElement.classList.add('dark');
        } else {
        document.documentElement.classList.remove('dark');
        }

    // Filter Dropdowns
    const languageFilterBtn = document.getElementById('languageFilterBtn');
    const languageFilterDropdown = document.getElementById('languageFilterDropdown');

    const platformFilterBtn = document.getElementById('platformFilterBtn');
    const platformFilterDropdown = document.getElementById('platformFilterDropdown');

    const priceFilterBtn = document.getElementById('priceFilterBtn');
    const priceFilterDropdown = document.getElementById('priceFilterDropdown');

        languageFilterBtn.addEventListener('click', () => {
        languageFilterDropdown.classList.toggle('hidden');
    platformFilterDropdown.classList.add('hidden');
    priceFilterDropdown.classList.add('hidden');
        });

        platformFilterBtn.addEventListener('click', () => {
        platformFilterDropdown.classList.toggle('hidden');
    languageFilterDropdown.classList.add('hidden');
    priceFilterDropdown.classList.add('hidden');
        });

        priceFilterBtn.addEventListener('click', () => {
        priceFilterDropdown.classList.toggle('hidden');
    languageFilterDropdown.classList.add('hidden');
    platformFilterDropdown.classList.add('hidden');
        });

        // Close dropdowns when clicking outside
        document.addEventListener('click', (e) => {
            if (!languageFilterBtn.contains(e.target) && !languageFilterDropdown.contains(e.target)) {
        languageFilterDropdown.classList.add('hidden');
            }

    if (!platformFilterBtn.contains(e.target) && !platformFilterDropdown.contains(e.target)) {
        platformFilterDropdown.classList.add('hidden');
            }

    if (!priceFilterBtn.contains(e.target) && !priceFilterDropdown.contains(e.target)) {
        priceFilterDropdown.classList.add('hidden');
            }
        });
</script>