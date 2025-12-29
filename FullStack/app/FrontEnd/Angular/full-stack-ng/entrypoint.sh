#!/bin/sh
envsubst < /etc/nginx/html/full-stack-ng/env.template.js > /etc/nginx/html/full-stack-ng/config/config.prod.json

exec nginx -g "daemon off;"
