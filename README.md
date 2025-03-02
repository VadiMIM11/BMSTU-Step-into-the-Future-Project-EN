# Determining the reliability of communication between two nodes of a computer network

## Overview

This project is a C# application developed for a coding competition hosted by Bauman Moscow State Technical University. It aims to determine the reliability of communication between two nodes in a computer network by comparing two distinct methods: an experimental (simulation-based) method and an analytical (logic-based) method.

## Purpose

The primary goal of the project is to evaluate and compare different approaches to assessing network reliability. In this context, reliability is defined as the probability that a signal originating from a source node will successfully reach a destination node. The project provides insights into the strengths and trade-offs of each method:

- **Experimental Method:** Uses a Monte Carlo simulation approach by performing a large number of experiments. In each experiment, node failures are simulated based on given reliability values, and the existence of at least one path from the source to the destination is checked.
- **Analytical Method:** Employs logical analysis using techniques such as disjunctive normal forms (DNF), truth tables, and the inclusion-exclusion principle to compute the exact probability of successful communication.

## Features

- **Graph-Based Network Modeling:**  
  Users can represent a computer network as a graph where:
  - **Nodes** represent devices (e.g., computers, sensors, routers) with associated reliability probabilities.
  - **Edges** represent ideal, failure-free communication channels between nodes.

- **Reliability Calculation:**
  - **Experimental Approach:**  
    Simulates multiple iterations to randomly determine node failures and checks for connectivity between selected source and destination nodes. The ratio of successful experiments approximates the network’s reliability.
  - **Analytical Approach:**  
    Constructs a logical expression representing all possible paths and uses probability theory (including the inclusion-exclusion principle) to compute an exact reliability value.

- **Path Finding Algorithms:**
  - **Breadth-First Search (BFS):**  
    Quickly finds any available path between the source and destination nodes.
  - **Depth-First Search (DFS):**  
    Enumerates all possible paths between the nodes, useful for detailed analysis.

- **Node Influence Rating:**  
  Provides a rating for each node that reflects its impact on the overall reliability, helping identify potential bottlenecks or “weak points” in the network.

- **User Interface:**  
  Built using Windows Forms, the UI allows users to:
  - Create and connect nodes visually.
  - Set the reliability of each node.
  - Select source and destination nodes.
  - Execute either the experimental or analytical method.
  - View results, including detailed node ratings and graphical representations of error versus the number of experiments.

## How It Works

1. **Input Data Format:**  
   The network is input as a graph. The user manually creates nodes (each with a specified reliability) and edges (representing communication links). The user also selects a source node (signal origin) and a destination node (signal target).

2. **Experimental Method:**  
   - For a user-specified number of iterations, the program simulates node failures based on their reliability.
   - After each simulation, it checks if there is at least one path from the source to the destination.
   - The reliability is approximated as the ratio of successful experiments to the total number of experiments.
   - This method is highly scalable and allows a trade-off between speed and accuracy by adjusting the number of experiments.

3. **Analytical Method:**  
   - The program models the successful transmission event as a logical expression based on the status (working or failed) of nodes.
   - It then simplifies the expression into a full disjunctive normal form (FDNF), ensuring that each term is mutually exclusive.
   - Using principles of probability (such as the inclusion-exclusion principle), the exact reliability is computed.
   - This method provides precise results but may become computationally intensive with large or complex networks.

4. **Auxiliary Algorithms:**  
   - **BFS and DFS:** Used to search for paths between nodes.
   - **Bitwise Operations:** Employed in the analytical method to optimize the computation of the logical expressions.

## Project Structure

The project is organized into several key classes:

- **MainForm:**  
  The primary window for user interaction, where the network graph is built and manipulated.

- **NodeRatingForm:**  
  Displays a table with node ratings, indicating the influence each node has on the overall reliability.

- **Graph:**  
  Represents the network model, holding nodes, edges, and computed paths.

- **Node:**  
  Represents an individual network node, including its reliability value and connections.

- **Path:**  
  Represents a sequence of nodes forming a communication path.

- **Experimentor:**  
  Handles the simulation and computation for the experimental method.

- **PathSearcher:**  
  Implements algorithms for finding paths (BFS for any path and DFS for all paths).

- **AnalyticalProcessor:**  
  Implements the analytical method, including logical expression management and probability calculations.

- **LinearLogicEquation & GraphEventProbabilityProvider:**  
  Support the analytical computations by representing logical expressions and mapping node indices to their probabilities.

For a visual representation of the project structure, refer to the class diagram below:

![Class Diagram](https://github.com/user-attachments/assets/2eb0c1db-3241-462a-b1d9-15eaf2fe530b)


## Screenshots

Here are some screenshots illustrating various aspects of the application:

- **Node Rating Table:**  
![Node Rating Table](https://github.com/user-attachments/assets/98c916f3-db41-4154-97f0-6efdbb0544c8)

- **Experimental Method Output:**  
![UI Experimental Method](https://github.com/user-attachments/assets/88c0d8f4-e448-4019-a0ea-130ca9aa963d)

- **Analytical Method Output:**  
![UI Analytical Method](https://github.com/user-attachments/assets/6e1d7c3a-0bcf-442e-be90-b28177daa7b7)

- **Experimental Error Graph:**  
![Experimental Error Graph](https://github.com/user-attachments/assets/e571adf0-840f-48e6-b60e-e45e13dc97d8)


## Conclusion

This project demonstrates two contrasting methods for determining the reliability of network communication. The experimental method offers a flexible, scalable solution suitable for large networks, while the analytical method delivers exact results, though at a higher computational cost. Together, they provide a comprehensive toolset for analyzing and optimizing the performance and reliability of computer networks.
