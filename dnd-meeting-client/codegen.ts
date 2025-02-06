
import type { CodegenConfig } from '@graphql-codegen/cli';

const config: CodegenConfig = {
  overwrite: true,
  schema: "http://localhost:5118/graphql",
  documents: "src/**/*.ts",
  generates: {
    "src/generated/graphql.ts": {
      plugins: ["typescript-apollo-angular"]
    },
    "./graphql.schema.json": {
      plugins: ["introspection"]
    }
  }
};

export default config;
