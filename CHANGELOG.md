# Changelog

All notable changes to the Apigen.Hetzner packages.

## [1.0.0] — unreleased

Initial release. Three independent generated clients plus an umbrella package:

- **Apigen.Hetzner.Cloud** — Hetzner Cloud API (`api.hetzner.cloud/v1`), Bearer token auth.
  Generated from the official `cloud.spec.json` OpenAPI 3.0.3 document.
- **Apigen.Hetzner.Api** — Hetzner unified API (`api.hetzner.com/v1`), Bearer token auth.
  Generated from the official `hetzner.spec.json` OpenAPI 3.0.3 document.
- **Apigen.Hetzner.Robot** — Hetzner Robot Webservice (`robot-ws.your-server.de`),
  HTTP Basic auth. Generated from a reverse-engineered OpenAPI spec produced by
  parsing Hetzner's official PHP reference client (paths/methods/params) and
  enriched with response schemas from the [community.hrobot Ansible collection](https://github.com/ansible-collections/community.hrobot).
- **Apigen.Hetzner** — umbrella meta-package; installs all three together.
