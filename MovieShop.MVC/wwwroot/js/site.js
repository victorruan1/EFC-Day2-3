// site.js - small helpers
document.addEventListener("DOMContentLoaded", function () {
  // Example: delegate click for purchase buttons
  document.body.addEventListener("click", function (e) {
    if (e.target && e.target.matches('[data-action="buy"]')) {
      const id = e.target.dataset.id;
      console.log("buy", id);
      // wire up AJAX call here
    }
  });
});
