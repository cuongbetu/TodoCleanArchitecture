#!/bin/bash
set -e

echo "Waiting for PostgreSQL to start..."
until pg_isready -h postgres -U postgres; do
  sleep 1
done

echo "Creating database TodoClean..."
psql -h postgres -U postgres -c 'CREATE DATABASE "TodoClean";'

echo "Database TodoClean created."
