This folder contains placeholders for vendor libraries. Recommended steps:

- Use LibMan to fetch Bootstrap and jQuery:
  libman install jquery -p cdnjs -d wwwroot/lib/jquery
  libman install bootstrap -p cdnjs -d wwwroot/lib/bootstrap

- Or add via npm/yarn and copy into wwwroot during build.

- You can also use CDN links directly in _Layout.cshtml for smaller repo size.
