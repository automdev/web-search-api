#!/usr/bin/env bash
# Search API – cURL example
# Usage: AUTOM_API_KEY=your-key bash search.sh
set -euo pipefail

curl -sS --fail-with-body -G "https://api.autom.dev/v1/search" \
  -H "x-api-key: ${AUTOM_API_KEY}" \
  --data-urlencode query=openai
