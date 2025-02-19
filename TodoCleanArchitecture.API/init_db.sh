#!/bin/bash
set -e

echo "Creating database TodoClean..."

# Create a new database
psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
    CREATE DATABASE TodoClean;
    GRANT ALL PRIVILEGES ON DATABASE TodoClean TO postgres;
EOSQL

echo "Database TodoClean created."
